CREATE PROCEDURE [dbo].[RegisterUser]
    @LastName VARCHAR(30),
    @FirstName VARCHAR(30),
    @MiddleName VARCHAR(30),
    @BirthDate DATE,
    @PassportSeries VARCHAR(4),
    @PassportNumber VARCHAR(6),
    @PhoneNumber VARCHAR(20),
    @Email VARCHAR(30),
    @Login VARCHAR(20),
    @Password VARCHAR(20),
    @Purpose VARCHAR(40)
AS
BEGIN
    SET NOCOUNT ON;

    -- ����������� ������������ � ������� ������������
    INSERT INTO [��������� ��� �������].[dbo].[������������] ([�������], [���], [��������], [����_��������], [�����_��������], [�����_��������], [�����_��������], [Email])
    VALUES (@LastName, @FirstName, @MiddleName, @BirthDate, @PassportSeries, @PassportNumber, @PhoneNumber, @Email);

    -- ��������� ID ������ ������������
    DECLARE @UserID INT;
    SET @UserID = SCOPE_IDENTITY();

    -- ����������� �������� ������������ � ������� �������
    INSERT INTO [��������� ��� �������].[dbo].[�������] ([���_������], [����_���������])
    VALUES (1, @Purpose);

    -- ��������� ID ������ ��������
    DECLARE @PassID INT;
    SET @PassID = SCOPE_IDENTITY();

    -- ����������� ������� ��������� ������������ � ������� ������ ���������
    INSERT INTO [��������� ��� �������].[dbo].[������ ���������] ([�����], [������], [����������], [���_������������], [���_��������])
    VALUES (@Login, @Password, @Purpose, @UserID, @PassID);
END;
