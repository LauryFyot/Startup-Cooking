-- #########################
-- DROP TRIGGER IF EXISTS
-- #########################
DROP TRIGGER IF EXISTS AFTER_ORDERTYPE_INSERT;
DROP TRIGGER IF EXISTS BEFORE_RECIPE_UPDATE;
DROP TRIGGER IF EXISTS AFTER_IS_IN_ORDERTYPE_INSERT;
DROP TRIGGER IF EXISTS AFTER_RECIPE_DELETE;

-- #########################
-- TRIGGER
-- #########################

-- AFTER IS_IN_ORDERTYPE INSERT
CREATE TRIGGER AFTER_ORDERTYPE_INSERT AFTER INSERT ON ORDERTYPE FOR EACH ROW
BEGIN
  -- To remove the client cart
  DELETE FROM IS_IN_CART_OF WHERE client_id = NEW.client_id;

  -- Best RECIPE_CREATOR of the week
  SET @bestRecipeCreatorWeekID = (SELECT IFNULL((SELECT recipe_creator_id FROM RECIPE NATURAL JOIN IS_IN_ORDERTYPE NATURAL JOIN ORDERTYPE 
      WHERE the_date >= (CURRENT_TIMESTAMP - INTERVAL 1 WEEK) GROUP BY recipe_creator_id ORDER BY SUM(nb_solded) desc LIMIT 1), NULL));

  -- Best RECIPE_CREATOR
  SET @bestRecipeCreatorID = (SELECT recipe_creator_id FROM RECIPE NATURAL JOIN IS_IN_ORDERTYPE
      GROUP BY recipe_creator_id ORDER BY SUM(nb_solded) desc LIMIT 1);

  -- To update DASHBOARD
  UPDATE DASHBOARD SET 
    best_recipe_creator_id_of_week = @bestRecipeCreatorWeekID,
    first_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 1), NULL)),
    second_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 2,1), NULL)),
    third_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 3,1), NULL)),
    fourth_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 4,1), NULL)),
    fifth_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 5,1), NULL)),
    best_recipe_creator_id = @bestRecipeCreatorID,
    first_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 1), NULL)),
    second_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 2,1), NULL)),
    third_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 3,1), NULL)),
    fourth_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 4,1), NULL)),
    fifth_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 5,1), NULL));
END;

-- BEFORE RECIPE UPDATE
CREATE TRIGGER BEFORE_RECIPE_UPDATE BEFORE UPDATE ON RECIPE FOR EACH ROW
BEGIN

  -- First recipe price hike
  IF (OLD.nb_solded <= 10 AND NEW.nb_solded > 10) THEN
    SET NEW.price = (NEW.price + 2);

  -- Second recipe price hike and first recipe creator fees hike
  ELSEIF (OLD.nb_solded <= 50 AND NEW.nb_solded > 50) THEN
    SET NEW.price = (NEW.price + 5);
    SET NEW.recipe_creator_fees = (NEW.recipe_creator_fees + 4);

  END IF;
END;

-- AFTER IS_IN_ORDERTYPE INSERT
CREATE TRIGGER AFTER_IS_IN_ORDERTYPE_INSERT AFTER INSERT ON IS_IN_ORDERTYPE FOR EACH ROW
BEGIN

  -- Decrement available quantity in product
  DECLARE done BOOLEAN DEFAULT FALSE;
  DECLARE local_product_id VARCHAR(36);
  DECLARE local_product_quantity MEDIUMINT UNSIGNED;

  DECLARE cursor_List CURSOR FOR
    SELECT product_id, quantity FROM PRODUCT NATURAL JOIN HAS_PRODUCT WHERE recipe_id = NEW.recipe_id;
  DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

  OPEN cursor_List;

  loop_List: LOOP
    FETCH cursor_List INTO local_product_id, local_product_quantity;
      IF done THEN
        LEAVE loop_List;
      END IF;

      UPDATE PRODUCT SET product_quantity = (product_quantity - (local_product_quantity * NEW.quantity)) WHERE product_id = local_product_id;

  END LOOP loop_List;

  CLOSE cursor_List;

  -- To increment the number of recipe solded
  UPDATE RECIPE SET nb_solded = (nb_solded + NEW.quantity) WHERE recipe_id = NEW.recipe_id;

  -- To pay the RECIPE_CREATOR
  UPDATE RECIPE_CREATOR SET cook_balance = cook_balance + (SELECT recipe_creator_fees FROM RECIPE WHERE recipe_id = NEW.recipe_id)
    WHERE recipe_creator_id = (SELECT recipe_creator_id FROM RECIPE WHERE recipe_id = NEW.recipe_id);

  -- Update cook balance if RECIPE_CREATOR buy this RECIPE
  SET @orderPrice = (SELECT SUM(price * NEW.quantity) FROM RECIPE WHERE recipe_id = NEW.recipe_id);
  UPDATE RECIPE_CREATOR SET cook_balance = GREATEST(0, cook_balance - @orderPrice) 
    WHERE recipe_creator_id = (SELECT client_id FROM ORDERTYPE WHERE order_id = NEW.order_id);

END;

-- AFTER RECIPE DELETE (To Update DASHBOARD When recipe is deleted)
CREATE TRIGGER AFTER_RECIPE_DELETE AFTER DELETE ON RECIPE FOR EACH ROW
BEGIN

  -- Best RECIPE_CREATOR
  SET @bestRecipeCreatorID = (SELECT recipe_creator_id FROM RECIPE GROUP BY recipe_creator_id ORDER BY SUM(nb_solded) desc LIMIT 1);

  -- To update DASHBOARD
  UPDATE DASHBOARD SET 
    first_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 1), NULL)),
    second_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 2,1), NULL)),
    third_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 3,1), NULL)),
    fourth_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 4,1), NULL)),
    fifth_recipe_id = (SELECT IFNULL((SELECT recipe_id FROM RECIPE ORDER BY nb_solded desc LIMIT 5,1), NULL)),
    best_recipe_creator_id = @bestRecipeCreatorID,
    first_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 1), NULL)),
    second_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 2,1), NULL)),
    third_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 3,1), NULL)),
    fourth_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 4,1), NULL)),
    fifth_recipe_id_of_best_rc = (SELECT IFNULL((SELECT recipe_id FROM RECIPE WHERE recipe_creator_id = @bestRecipeCreatorWeekID ORDER BY nb_solded desc LIMIT 5,1), NULL));
END;