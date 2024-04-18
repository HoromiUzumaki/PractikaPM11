-- Создание функции для генерации уникального логина
CREATE FUNCTION dbo.GENERATE_UNIQUE_LOGIN(@FirstName VARCHAR(30), @LastName VARCHAR(30), @BirthDate DATE)
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @Login VARCHAR(50);
    DECLARE @Counter INT = 1;
    DECLARE @BaseLogin VARCHAR(50);
    SET @BaseLogin = LOWER(LEFT(@FirstName, 1) + @LastName);

    -- Проверяем, существует ли уже логин с таким именем
    WHILE EXISTS (SELECT 1 FROM Пользователи WHERE Логин = @BaseLogin)
    BEGIN
        -- Если логин уже существует, добавляем числовой суффикс
        SET @Login = @BaseLogin + CAST(@Counter AS VARCHAR(5));
        SET @Counter = @Counter + 1;
    END

    -- Возвращаем сгенерированный уникальный логин
    RETURN @Login;
END;
GO

