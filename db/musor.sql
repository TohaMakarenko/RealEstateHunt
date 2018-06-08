select * from RealEstate re

select * from RealEstateType ret

insert into RealEstateType (Name)
values ('Квартира');

insert into City (Name)
values ('Kiev');

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
(1, 'QQRR', 1, 2, 'RH2', '2rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH3', '3rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH4', '4rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH5', '5rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH6', '6rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH7', '6rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH8', '7rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH9', '8rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH10', '9rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH11', '10rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH12', '11rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH13', '12rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH14', '13rr', 114, 24, 'BOrsch', 1),
(1, 'QQRR', 1, 2, 'RH15', '14rr', 114, 24, 'BOrsch', 1)
