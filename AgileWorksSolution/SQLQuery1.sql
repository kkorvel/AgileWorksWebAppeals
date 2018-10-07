CREATE LOGIN Tester WITH PASSWORD = 'test123';
CREATE USER Tester FOR LOGIN Tester;
exec sp_addrolemember 'db_owner', 'Tester'