-- =============================================
-- Author:		Muhammad Iqbal
-- Create date: 09-02-2020
-- Description:	Delete Candidate
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteCandidate]
	@candidateId INT
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE 
		Votes
	SET	
		CandidateId = NULL
	WHERE 
		CandidateId = @candidateId;

	DELETE FROM 
		Candidates
	WHERE 
		Id = @candidateId;
END