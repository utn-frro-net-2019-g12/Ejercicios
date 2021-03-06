-- Create User Net
CREATE LOGIN net WITH PASSWORD = 'net', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
GO

Use tp2_net;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'net')
BEGIN
    CREATE USER [net] FOR LOGIN [net]
    EXEC sp_addrolemember N'db_owner', N'net'
END;
GO

------------------------------------------------------------

-- Create User Net3
CREATE LOGIN net3 WITH PASSWORD = 'net3', CHECK_EXPIRATION = OFF, CHECK_POLICY = OFF;
GO

Use tp2_net;
GO

IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'net3')
BEGIN
    CREATE USER [net3] FOR LOGIN [net3]
    EXEC sp_addrolemember N'db_owner', N'net3'
END;
GO
