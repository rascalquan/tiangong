DROP TABLE `hotel`;

CREATE TABLE IF NOT EXISTS `hotel`(
    `id` bigint(20) NOT NULL,
    `name` VARCHAR(50) NOT NULL,
    `telphone` VARCHAR(20),
    `address` VARCHAR(100),
    `star` int,
    `createby` VARCHAR(50),
    `createtime` datetime,
    `lastupdateby` VARCHAR(50),
    `lastupdatetime` datetime,
    PRIMARY key(`id`)
)ENGINE=InnoDB DEFAULT CHARSET=utf8;