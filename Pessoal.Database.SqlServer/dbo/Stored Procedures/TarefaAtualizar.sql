Create procedure TarefaAtualizar
	@id int = null,	
	@Nome nvarchar(200)
	,@Prioridade int
	,@Concluida bit
	,@Observacoes nvarchar(1000) 	
as

UPDATE [dbo].[Tarefa]
   SET [Nome] = @Nome
      ,[Prioridade] = @Prioridade
      ,[Concluida] = @Concluida
      ,[Observacoes] = @Observacoes
 WHERE Id = @id
