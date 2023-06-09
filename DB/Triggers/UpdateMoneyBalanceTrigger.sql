USE [Pawnshop]
GO
/****** Object:  Trigger [Pawnshop].[UpdateMoneyBalance]    Script Date: 21.12.2021 09:22:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER   TRIGGER [Worker].[UpdateMoneyBalance] ON [Worker].[DealDocument]
FOR INSERT
	,DELETE
AS
BEGIN

IF (@@ROWCOUNT != 1)
RETURN;

	IF EXISTS (
			SELECT 1
			FROM INSERTED
			)
	BEGIN
		UPDATE MoneyBalance
		SET MoneyBalance = MoneyBalance + (
				SELECT (ISNULL(i.Income, 0) + ISNULL(i.RepaymentCapital, 0) - ISNULL(i.Cost, 0))
				FROM inserted i
				)
		WHERE TodayDate = (
				SELECT MoneyBalanceID
				FROM inserted
				)
	END
	ELSE
	BEGIN
		UPDATE MoneyBalance
		SET MoneyBalance = MoneyBalance - (
				SELECT (ISNULL(d.Income, 0) + ISNULL(d.RepaymentCapital, 0) - ISNULL(d.Cost, 0))
				FROM deleted d
				)
		WHERE TodayDate = (
				SELECT MoneyBalanceID
				FROM deleted
				)
	END
END;