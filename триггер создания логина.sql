
-- �������� �������� ��� �������������� ��������� ����������� ������ ��� ������� ����� ������ � ������� ������������
CREATE TRIGGER trg_GenerateUniqueLogin
ON ������������
AFTER INSERT
AS
BEGIN
    DECLARE @FirstName VARCHAR(30);
    DECLARE @LastName VARCHAR(30);
    DECLARE @BirthDate DATE;
    DECLARE @NewLogin VARCHAR(50);

    -- �������� ������ � ����������� ������������
    SELECT @FirstName = �������, @LastName = ���, @BirthDate = ����_��������
    FROM inserted;

    -- ���������� ���������� �����
    SET @NewLogin = dbo.GENERATE_UNIQUE_LOGIN(@FirstName, @LastName, @BirthDate);

    -- ��������� ����� � ����� ������
    UPDATE ������������
    SET ����� = @NewLogin
    WHERE ���_������������ IN (SELECT ���_������������ FROM inserted);
END;
GO