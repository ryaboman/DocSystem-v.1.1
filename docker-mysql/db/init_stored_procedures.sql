USE `sn_system`;
DROP procedure IF EXISTS `AddDestination`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddDestination`(surname VARCHAR(45), destName VARCHAR(45), destPatronymic VARCHAR(45), destPost VARCHAR(70), genitivePost VARCHAR(100))
    SQL SECURITY INVOKER
BEGIN
	DECLARE today DATE;
	SELECT CURDATE() INTO today;
    
	INSERT INTO destination (dest_surname, dest_name, dest_patronymic, emp_position, genitive_dest, date_dest)
	VALUES (surname, destName, destPatronymic, destPost, genitivePost,  today); 
END$$

DELIMITER ;



USE `sn_system`;
DROP procedure IF EXISTS `AddPerformer`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `AddPerformer`(PCName VARCHAR(45), surnameIN VARCHAR(45), nameIN VARCHAR(45), patronymicIN VARCHAR(45), departmentIN VARCHAR(45), postIN VARCHAR(100), phoneIN VARCHAR(45))
    SQL SECURITY INVOKER
BEGIN
	INSERT INTO performer (user_name, surname, name, patronymic, department, post, number_phone)
	VALUES (PCName, surnameIN, nameIN, patronymicIN, departmentIN, postIN, phoneIN); 
END$$

DELIMITER ;



USE `sn_system`;
DROP procedure IF EXISTS `DeleteSN`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteSN`(id VARCHAR(45), numberSN VARCHAR(45))
    SQL SECURITY INVOKER
BEGIN
	INSERT INTO deleted_sn (count_sn) 
    VALUES (numberSN);
    
    DELETE FROM service_note WHERE id_sn = id;
END$$

DELIMITER ;



USE `sn_system`;
DROP procedure IF EXISTS `GetNumberDoc`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `GetNumberDoc`(out count_sn_out INT)
    SQL SECURITY INVOKER
BEGIN
	DECLARE count_id INT;    
    DECLARE today DATE;
	#Если flag = true то полученный номер записываем в БД (flag bool) Нужно?
    
    #начнем транзакцию
	START TRANSACTION;
    SET AUTOCOMMIT=0;
    
	SELECT COUNT(*) INTO count_id
    FROM deleted_sn;
    If (count_id) THEN
		SELECT count_sn INTO count_sn_out
        FROM deleted_sn
        ORDER BY count_sn
        LIMIT 1;
              
        SELECT CURDATE() INTO today; 
        
        INSERT INTO service_note (count_sn, number_sn, name_sn, destination, user, date)
		VALUES (count_sn_out, count_sn_out, "Документ", 1, null,  today); 
                    
        DELETE FROM deleted_sn WHERE count_sn = count_sn_out;
        
	ELSE
		BEGIN
			SELECT count_sn INTO count_sn_out 
			FROM service_note
			ORDER BY count_sn DESC  #Возможно здесь нужно не с помощью сортировки. А как?? Может с помощью курсоров
			LIMIT 1;
            
			SELECT count_sn_out + 1 INTO count_sn_out;
            
            SELECT CURDATE() INTO today;
            
            INSERT INTO service_note (count_sn, service_note.number_sn, name_sn, destination, user, date)
			VALUES (count_sn_out, count_sn_out, "Документ", 1, null,  today); 
		END;
	END IF;	
            
    #При этом нужно сделать запись в таблицу со СЗ

	COMMIT;
    SET AUTOCOMMIT=1;
      
END$$

DELIMITER ;



USE `sn_system`;
DROP procedure IF EXISTS `RefreshBasket`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `RefreshBasket`()
    SQL SECURITY INVOKER
BEGIN
	TRUNCATE TABLE deleted_sn;
END$$

DELIMITER ;




USE `sn_system`;
DROP procedure IF EXISTS `SetNumberDoc`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `SetNumberDoc`(numberDocIN VARCHAR(4), OUT id_doc VARCHAR(45))
    SQL SECURITY INVOKER
BEGIN	
	DECLARE countNumber INT; 
    DECLARE id_number INT; #id записи в которой есть номер numberDocIN  RefreshBasket() id_doc
    DECLARE today DATE;
    DECLARE MaxNumber VARCHAR(4);        #максимальный номер документа из deleted_sn и service_note
    DECLARE MaxNumberFromSN VARCHAR(4);  #максимальный номер документа из service_note
    DECLARE MaxNumberFromDT VARCHAR(4);  #максимальный номер документа из deleted_sn

	#начнем транзакцию
	START TRANSACTION;
    SET AUTOCOMMIT=0;

	SELECT COUNT(*) FROM service_note WHERE count_sn = numberDocIN INTO countNumber;
    
    SELECT MAX(count_sn) FROM service_note INTO MaxNumberFromSN;
    SELECT MAX(count_sn) FROM deleted_sn INTO MaxNumberFromDT;
    
    #¬ычисл¤ем максимальное число
    IF(MaxNumberFromSN >= MaxNumberFromDT) THEN
		SELECT MaxNumberFromSN INTO MaxNumber;
	ELSE
		SELECT MaxNumberFromDT INTO MaxNumber;
    END IF;
    	
    If (!countNumber) THEN #если ничего не нашли, то    		
        
        #«аписываем номер
        SELECT CURDATE() INTO today; #&&&????
        INSERT INTO service_note (count_sn, service_note.number_sn, name_sn, destination, user, date)
		VALUES (numberDocIN, numberDocIN, "документ", null, null,  today);     
		
        #≈сли записываемое значение больше всех максимальных значение, то очищаем таблицу deleted_sn
        IF(numberDocIN >= MaxNumber) THEN
			CALL RefreshBasket();
		END IF;
        
        #теперь если данный номер существует в таблице deleted_sn
        SELECT id_deleted_sn FROM deleted_sn WHERE count_sn = numberDocIN INTO id_number;
        IF(id_number) THEN #если существуе, то нужно удалить        
			DELETE FROM deleted_sn WHERE id_deleted_sn = id_number;
        END IF;
        
        SELECT id_sn FROM service_note WHERE count_sn = numberDocIN INTO id_doc;
    ELSE
		SELECT null INTO id_doc; #На всякий случай обнуляем
    END IF;
    
    
	#ѕровер¤ем нет ли данного номера в service_note и в deleted_sn
    #≈сли нет, то
		#Ќаходим наибольший номер в данных таблицах
		#≈сли numberDocIN больше наибольшего номера, то удал¤ем все номера из deleted_sn и записываем в таблицу service_note
		#≈сли нет, то записываем в таблицу service_note
        
	COMMIT;
    SET AUTOCOMMIT=1;
END$$

DELIMITER ;




USE `sn_system`;
DROP procedure IF EXISTS `UpdateDestination`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateDestination`(id VARCHAR(45), surname VARCHAR(45), destName VARCHAR(45), destPatronymic VARCHAR(45), destPost VARCHAR(70), genitivePost VARCHAR(100))
    SQL SECURITY INVOKER
BEGIN
	DECLARE today DATE;
	SELECT CURDATE() INTO today;
    
    UPDATE destination
    SET dest_surname = surname,
		dest_name = destName,
        dest_patronymic = destPatronymic,
        emp_position = destPost,
        genitive_dest = genitivePost,
        date_dest = today
	WHERE id_destination = id;
END$$

DELIMITER ;


USE `sn_system`;
DROP procedure IF EXISTS `UpdatePerformer`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdatePerformer`(id VARCHAR(45), PCName VARCHAR(45), surnameIN VARCHAR(45), nameIN VARCHAR(45), patronymicIN VARCHAR(45), departmentIN VARCHAR(45), postIN VARCHAR(100), phoneIN VARCHAR(45))
    SQL SECURITY INVOKER
BEGIN

    UPDATE performer
    SET user_name = PCName,
		surname = surnameIN,
        name = nameIN,
        patronymic = patronymicIN,
        department = departmentIN,
        post = postIN,
        number_phone = phoneIN        
	WHERE id_user = id;
END$$

DELIMITER ;



USE `sn_system`;
DROP procedure IF EXISTS `UpdateSN`;

DELIMITER $$
USE `sn_system`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateSN`(numberSN VARCHAR(45), nameSN VARCHAR(100), destinationSN VARCHAR(10), textSN VARCHAR(256), performerSN VARCHAR(10), pathSN VARCHAR(200), markSN VARCHAR(45), dateDoc VARCHAR(45))
    SQL SECURITY INVOKER
BEGIN
	DECLARE today DATE;
	SELECT CURDATE() INTO today;
    
	UPDATE service_note
    SET name_sn = nameSN,
        destination = destinationSN,
        user = performerSN,
        date = dateDoc,
        summary = textSN,
        path = pathSN,
        number_sn = markSN
	WHERE count_sn = numberSN; 
END$$

DELIMITER ;