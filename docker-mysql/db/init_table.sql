USE `sn_system`;

DROP TABLE IF EXISTS `deleted_sn`;
CREATE TABLE `deleted_sn` (
  `id_deleted_sn` int(11) NOT NULL AUTO_INCREMENT,
  `count_sn` int(11) NOT NULL,
  PRIMARY KEY (`id_deleted_sn`),
  UNIQUE KEY `count_sn_UNIQUE` (`count_sn`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='”даленные служебные записки';

DROP TABLE IF EXISTS `destination`;
CREATE TABLE `destination` (
  `id_destination` int(11) NOT NULL AUTO_INCREMENT,
  `dest_surname` varchar(45) NOT NULL,
  `dest_name` varchar(45) NOT NULL,
  `dest_patronymic` varchar(45) NOT NULL,
  `emp_position` varchar(70) NOT NULL COMMENT 'Employee''s position - должность сотрудника',
  `genitive_dest` varchar(100) NOT NULL COMMENT 'Должность, фамилия и инициалы в родительном падеже\nФорма обращения в СЗ',
  `date_dest` date DEFAULT NULL,
  PRIMARY KEY (`id_destination`),
  UNIQUE KEY `emp_position_UNIQUE` (`emp_position`),
  UNIQUE KEY `Genitive_dest_UNIQUE` (`genitive_dest`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8 COMMENT='Адресат. На чье имя выпушена данная служебная записка';

DROP TABLE IF EXISTS `performer`;
CREATE TABLE `performer` (
  `id_user` int(11) NOT NULL AUTO_INCREMENT,
  `user_name` varchar(45) NOT NULL COMMENT 'Имя компьютера пользователя',
  `surname` varchar(45) NOT NULL,
  `name` varchar(45) NOT NULL,
  `patronymic` varchar(45) NOT NULL,
  `department` varchar(45) NOT NULL,
  `post` varchar(100) DEFAULT NULL,
  `number_phone` varchar(45) NOT NULL,
  PRIMARY KEY (`id_user`),
  UNIQUE KEY `user_name_UNIQUE` (`user_name`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8 COMMENT='Таблица пользователей SN-системой';

DROP TABLE IF EXISTS `service_note`;
CREATE TABLE `service_note` (
  `id_sn` int(11) NOT NULL AUTO_INCREMENT,
  `count_sn` int(11) NOT NULL,
  `number_sn` varchar(45) NOT NULL,
  `name_sn` varchar(45) NOT NULL,
  `destination` int(11) DEFAULT NULL,
  `user` int(11) DEFAULT NULL,
  `date` date NOT NULL,
  `summary` text,
  `path` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`id_sn`),
  UNIQUE KEY `number_sn_UNIQUE` (`number_sn`),
  UNIQUE KEY `count_sn_UNIQUE` (`count_sn`),
  KEY `fk_distination_idx` (`destination`),
  KEY `fk_user_idx` (`user`),
  CONSTRAINT `fk_destination` FOREIGN KEY (`destination`) REFERENCES `destination` (`id_destination`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `fk_user` FOREIGN KEY (`user`) REFERENCES `performer` (`id_user`) ON DELETE SET NULL ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=113 DEFAULT CHARSET=utf8 COMMENT='Головная таблица системы';

DROP TABLE IF EXISTS `variable`;
CREATE TABLE `variable` (
  `id_variable` int(11) NOT NULL AUTO_INCREMENT,
  `var_name` varchar(45) DEFAULT NULL,
  `value` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id_variable`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COMMENT='Переменные';