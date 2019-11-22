CREATE PROCEDURE [dbo].[TarefaInserir]
	@Nome nvarchar(200)
	,@Prioridade int
	,@Concluida bit
	,@Observacoes nvarchar(1000) 	
AS
BEGIN

	INSERT INTO [dbo].[Tarefa]
			(
			[Nome]
			,[Prioridade]
			,[Concluida]
			,[Observacoes]
			)
			output inserted.Id
		VALUES
			(
			@Nome
			,@Prioridade
			,@Concluida
			,@Observacoes
			)
			
END
