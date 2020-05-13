###################
-- DROP EVENT IF EXISTS
-- #########################
DROP EVENT IF EXISTS product_stock_manager;

-- #########################
-- EVENT EVERY MONDAY
-- #########################
CREATE EVENT PRODUCT_STOCK_MANAGER ON SCHEDULE EVERY 1 WEEK STARTS CURRENT_DATE + INTERVAL 6 - WEEKDAY(CURRENT_DATE) DAY
DO BEGIN
  -- To update min_quantity
  UPDATE PRODUCT SET min_quantity = min_quantity + (min_quantity - quantity);

  -- To update quantity and max_quantity
  UPDATE PRODUCT SET max_quantity = min_quantity * 2, quantity = (max_quantity + min_quantity) / 2; 
END;