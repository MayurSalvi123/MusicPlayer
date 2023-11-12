INSERT INTO "Users" ("Id", "FirstName", "LastName", "Email", "Password", "PhoneNumber", "IsDeleted")
SELECT '38c9fcdc-e1a7-40f0-8fdc-740a920b2652', 'Admin','Admin','admin@email.com','qwe123','123456',false
WHERE NOT EXISTS (
SELECT null from "Users"
WHERE ("FirstName", "LastName") = ('Admin','Admin')
);