Create procedure TarefaSelecionar
	@id int = null
as

SELECT [Id]
      ,[Nome]
      ,[Prioridade]
      ,[Concluida]
      ,[Observacoes]
  FROM [dbo].[Tarefa]
  where Id = ISNULL(@id, Id)
  Order by Concluida, Prioridade