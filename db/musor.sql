select * from RealEstate re

select * from RealEstateType ret

select * from RealEstateType ret

insert into RealEstateType (Name)
values ('Будинок');

insert into City (Name)
values ('Dnipro');

insert into District (CityId, Name)
values (1, 'Soloma');

insert into RealEstate (CityId, Description, DistrictId, Floor, Name, Number, Price, Square, Street, TypeId)
values (1, 'QQRR', 1, 2, 'RH1', '22rr', 114, 24, 'BOrsch', 1);

select * from RealEstate re

  

insert into Contact (BankAccountNumber, BirthDate, CityId, DistrictId, FirstName, LastName, Number, PreferredPrice, PreferredTypeId, Street)
values ('1337', GETDATE(), 1, 1, 'FirstName', 'LastName', '223', 14, 1, 'Stree');

select * from Contact c


insert into RealEstate (CityId, Description, DistrictId, Floor, Name, Number, Price, Square, Street, TypeId)
values 
(1, 'QQRR2', 1, 2, 'RH2', '2rr', 114, 24, 'BOrsch2', 1),
(1, 'QQRR3', 1, 2, 'RH3', '3rr', 114, 24, 'BOrsch3', 1),
(1, 'QQRR4', 1, 2, 'RH4', '4rr', 114, 24, 'BOrsch4', 1),
(1, 'QQRR5', 1, 2, 'RH5', '5rr', 114, 24, 'BOrsch5', 1),
(1, 'QQRR6', 1, 2, 'RH6', '6rr', 114, 24, 'BOrsch6', 1),
(1, 'QQRR7', 1, 2, 'RH7', '6rr', 114, 24, 'BOrsch7', 1),
(1, 'QQRR8', 1, 2, 'RH8', '7rr', 114, 24, 'BOrsch8', 1),
(1, 'QQRR9', 1, 2, 'RH9', '8rr', 114, 24, 'BOrsch9', 1),
(1, 'QQRR10', 1, 2, 'RH10', '9rr', 114, 24, 'BOrsch10', 1),
(1, 'QQRR11', 1, 2, 'RH11', '10rr', 114, 24, 'BOrsch11', 1),
(1, 'QQRR12', 1, 2, 'RH12', '11rr', 114, 24, 'BOrsch12', 1),
(1, 'QQRR13', 1, 2, 'RH13', '12rr', 114, 24, 'BOrsch13', 1),
(1, 'QQRR14', 1, 2, 'RH14', '13rr', 114, 24, 'BOrsch14', 1),
(1, 'QQRR15', 1, 2, 'RH15', '14rr', 114, 24, 'BOrsch15', 1)

select * from RealEstate re
    order by id 

    SELECT [c].[Id], [c].[Name]
FROM [City] AS [c]


select * from RealEstate re