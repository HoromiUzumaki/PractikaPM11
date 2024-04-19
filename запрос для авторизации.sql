DECLARE @Login VARCHAR(20) = 'введенный логин';
DECLARE @Password VARCHAR(20) = 'введенный пароль';
DECLARE @IsSuccessful BIT;
DECLARE @UserID INT;

-- Проверяем наличие пользователя в таблице "Групповое посещение"
IF EXISTS (SELECT 1 FROM [dbo].[Групповое посещение] WHERE [Логин] = @Login AND [Пароль] = @Password)
BEGIN
    SELECT @UserID = Код_пользователя FROM [dbo].[Групповое посещение] WHERE [Логин] = @Login;
    SET @IsSuccessful = 1;
END
ELSE
BEGIN
    -- Если пользователь не найден в таблице "Групповое посещение", проверяем таблицу "Личное посещение"
    IF EXISTS (SELECT 1 FROM [dbo].[Личное посещение] WHERE [Логин] = @Login AND [Пароль] = @Password)
    BEGIN
        SELECT @UserID = Код_пользователя FROM [dbo].[Личное посещение] WHERE [Логин] = @Login;
        SET @IsSuccessful = 1;
    END
    ELSE
    BEGIN
        -- Если пользователь не найден ни в одной из таблиц, устанавливаем флаг успешной авторизации в 0
        SET @IsSuccessful = 0;
    END
END

SELECT @IsSuccessful AS IsSuccessful, @UserID AS UserID;
