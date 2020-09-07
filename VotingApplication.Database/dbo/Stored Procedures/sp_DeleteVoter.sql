-- =============================================
-- Author:		Muhammad Iqbal
-- Create date: 09-02-2020
-- Description:	Delete Voter
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteVoter]
	@voterId INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		Votes
	SET	
		voterId = NULL
	WHERE 
		voterId = @voterId;

	DELETE FROM 
		Voters
	WHERE 
		Id = @voterId;
END