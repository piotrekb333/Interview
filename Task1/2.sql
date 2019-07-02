CREATE PROCEDURE [dbo].[LoadDimension] 
AS 
  BEGIN 
      -- SET NOCOUNT ON added to prevent extra result sets from 
      -- interfering with SELECT statements. 
      SET nocount ON; 

      -- Insert statements for procedure here 
      BEGIN TRANSACTION 

      UPDATE dimension 
      SET    dimension.value = st.value 
      FROM   dimension di 
             CROSS apply (SELECT TOP 1 value 
                          FROM   staging st2 
                          WHERE  st2.NAME = di.NAME) st 

      UPDATE dimension 
      SET    isdeleted = 1 
      WHERE  NAME NOT IN (SELECT NAME 
                          FROM   staging st 
                          WHERE  dimension.NAME = st.NAME); 

      WITH helpstaging 
           AS (SELECT p.NAME, 
                      p.value, 
                      Row_number() 
                        OVER( 
                          partition BY p.NAME 
                          ORDER BY p.NAME DESC) AS rk 
               FROM   staging p) 

      INSERT INTO dimension 
                  (NAME, 
                   value, 
                   isdeleted) 
      SELECT st.NAME, 
             st.value, 
             0 
      FROM   helpstaging st 
      WHERE  st.NAME NOT IN (SELECT NAME 
                             FROM   dimension d 
                             WHERE  st.NAME = d.NAME) 
             AND st.rk = 1 

      COMMIT TRANSACTION 
  END 
