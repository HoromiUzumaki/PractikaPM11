DECLARE @Login VARCHAR(20) = '��������� �����';
DECLARE @Password VARCHAR(20) = '��������� ������';
DECLARE @IsSuccessful BIT;
DECLARE @UserID INT;

-- ��������� ������� ������������ � ������� "��������� ���������"
IF EXISTS (SELECT 1 FROM [dbo].[��������� ���������] WHERE [�����] = @Login AND [������] = @Password)
BEGIN
    SELECT @UserID = ���_������������ FROM [dbo].[��������� ���������] WHERE [�����] = @Login;
    SET @IsSuccessful = 1;
END
ELSE
BEGIN
    -- ���� ������������ �� ������ � ������� "��������� ���������", ��������� ������� "������ ���������"
    IF EXISTS (SELECT 1 FROM [dbo].[������ ���������] WHERE [�����] = @Login AND [������] = @Password)
    BEGIN
        SELECT @UserID = ���_������������ FROM [dbo].[������ ���������] WHERE [�����] = @Login;
        SET @IsSuccessful = 1;
    END
    ELSE
    BEGIN
        -- ���� ������������ �� ������ �� � ����� �� ������, ������������� ���� �������� ����������� � 0
        SET @IsSuccessful = 0;
    END
END

SELECT @IsSuccessful AS IsSuccessful, @UserID AS UserID;
