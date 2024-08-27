BEGIN TRANSACTION
    DELETE FROM Movies
    SELECT * FROM Movies -- Will show no movies at all
ROLLBACK TRANSACTION
--COMMIT TRANSACTION 
SELECT * FROM Movies -- Will show all movies