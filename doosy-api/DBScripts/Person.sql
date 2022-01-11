CREATE TABLE `Person` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Firstname` varchar(45) DEFAULT NULL,
  `Surname` varchar(45) DEFAULT NULL,
  `Status` varchar(45) DEFAULT NULL,
  `CreatedBy` varchar(45) DEFAULT NULL,
  `DateCreated` datetime DEFAULT NULL,
  `Gender` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
