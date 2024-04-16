CREATE PROCEDURE AuthenticateUser
    @Login VARCHAR(20),
    @Password VARCHAR(20),
    @IsSuccessful BIT OUTPUT,
    @UserID INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    -- ��������� ������� ������������ � ������� "��������� ���������"
    SELECT @UserID = ���_������������
    FROM [dbo].[��������� ���������]
    WHERE [�����] = @Login AND [������] = @Password;

    IF @UserID IS NOT NULL
    BEGIN
        SET @IsSuccessful = 1;
        RETURN;
    END

    -- ���� ������������ �� ������ � ������� "��������� ���������", ��������� ������� "������ ���������"
    SELECT @UserID = ���_������������
    FROM [dbo].[������ ���������]
    WHERE [�����] = @Login AND [������] = @Password;

    IF @UserID IS NOT NULL
    BEGIN
        SET @IsSuccessful = 1;
        RETURN;
    END

    -- ���� ������������ �� ������ �� � ����� �� ������, ���������� ������
    SET @IsSuccessful = 0;
END;