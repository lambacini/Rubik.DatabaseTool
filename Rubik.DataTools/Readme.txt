Nesneler bir birine bağımlı olduğu için (Foreign key) önce bağımlılıkları oluşturmak gerekiyor.

Tablonun bağımlılıklarını bulabilmek için .

select * from sys.all_constraints
where table_name = 'STUDY'
and owner = 'FONETPACS'
and constraint_type in ( 'R', 'C')
order by decode(constraint_type, 'P', 0, 'U', 1, 'R', 2, 3), constraint_name

1	FONETPACS	FK_STUDY_FILESYSTEMID	R	STUDY	<Long>	FONETPACS	PK_FILESYSTEM	NO ACTION
2	FONETPACS	FK_STUDY_PATIENTID	R	STUDY	<Long>	FONETPACS	PK_PATIENT	CASCADE
3	FONETPACS	FK_STUDY_SERVERID	R	STUDY	<Long>	FONETPACS	PK_DICOMSERVER	NO ACTION

select table_name from sys.all_constraints
where constraint_name = 'PK_FILESYSTEM'
and owner = 'FONETPACS'
and constraint_type in ('P', 'U')



örnekte STUDY tablosunun bağımlı olduğu tablolar listeleniyor STUDY tablosundan önce bu tabloların oluşturulması gerekiyor.
PK_FILESYSTEM Keyinin ait olduğu tabloyu bulup aynı kontorlleri o tablo içinde yapmak gerekiyor.

Tablo oluşturulurken bağımlı olduğu tablolar bir alanda saklanarak scriptin oluşturulma aşamasında önce bu tabloların oluşturulması sağlanır. 

Her tablonun varsayılan sort değeri 1000 olarak verilir. 

script oluşturma aşamasında bağımlı olduğu her nesne için -1 ile toplanır. işlemin sonunda Tablolar sort değerine göre küçükten büyüğe sıralanır böylece 
en çok bağımlılığı olan tablo en üstte oluşturulması sağlanır !


SELECT * FROM USER_TAB_STATISTICS 


select index_name, last_analyzed, global_stats
from user_indexes
order by index_name
