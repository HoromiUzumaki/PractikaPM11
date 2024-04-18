
-- Создание триггера для автоматической генерации уникального логина при вставке новой записи в таблицу Пользователи
CREATE TRIGGER trg_GenerateUniqueLogin
ON Пользователи
AFTER INSERT
AS
BEGIN
    DECLARE @FirstName VARCHAR(30);
    DECLARE @LastName VARCHAR(30);
    DECLARE @BirthDate DATE;
    DECLARE @NewLogin VARCHAR(50);

    -- Получаем данные о вставленном пользователе
    SELECT @FirstName = Фамилия, @LastName = Имя, @BirthDate = Дата_рождения
    FROM inserted;

    -- Генерируем уникальный логин
    SET @NewLogin = dbo.GENERATE_UNIQUE_LOGIN(@FirstName, @LastName, @BirthDate);

    -- Обновляем логин в новой записи
    UPDATE Пользователи
    SET Логин = @NewLogin
    WHERE Код_пользователя IN (SELECT Код_пользователя FROM inserted);
END;
GO