# start-master // iniciar o spark
# stop-master // parar o spark
from pyspark.sql import SparkSession

#https://www.kaggle.com/inquisitivecrow/crime-data-in-brazil

spark = SparkSession.builder.appName('Basics').getOrCreate()
dataframe = spark.read.csv('BO_2016.csv', sep=",", header=True)
dataframe = dataframe.drop('_c21')
dataframe.createOrReplaceTempView("crimes")

#dataframe.printSchema()

spark.sql (
    '''
        SELECT 
            Cast(NUM_BO as Int) as NUM_BO
            ,Cast(ID_DELEGACIA as Int) as ID_DELEGACIA
            ,ANO_BO
            ,NOME_DEPARTAMENTO
            ,NOME_SECCIONAL
            ,DELEGACIA
            ,NOME_DEPARTAMENTO_CIRC
            ,NOME_SECCIONAL_CIRC
            ,NOME_DELEGACIA_CIRC
            ,year(ANO) as ANO
            ,month(MES) as MES
            ,FLAG_STATUS11
            ,RUBRICA
            ,DESDOBRAMENTO
            ,CONDUTA
            ,hash(concat(LATITUDE ,LONGITUDE ,CIDADE ,LOGRADOURO ,NUMERO_LOGRADOURO,'sk_local'))as sk_local
            ,LATITUDE
            ,LONGITUDE
            ,CIDADE
            ,LOGRADOURO
            ,NUMERO_LOGRADOURO
            ,FLAG_STATUS20
        FROM crimes
    '''
)

dim_delegacia =  spark.sql (
    '''
        SELECT distinct 
            ID_DELEGACIA as sk_delegacia
            ,ID_DELEGACIA            
            ,DELEGACIA as nm_delegacia           
        FROM crimes
    '''
)

dim_local =  spark.sql (
    '''
        SELECT distinct 
             hash(concat(LATITUDE ,LONGITUDE ,CIDADE ,LOGRADOURO ,NUMERO_LOGRADOURO,'sk_local'))as sk_local
            ,LATITUDE
            ,LONGITUDE
            ,CIDADE
            ,LOGRADOURO
            ,NUMERO_LOGRADOURO
        FROM crimes
    '''
)

ft_crimes = spark.sql (
    '''
        SELECT 
            Cast(ID_DELEGACIA as Int) as sk_delegacia            
            ,hash(concat(LATITUDE ,LONGITUDE ,CIDADE ,LOGRADOURO ,NUMERO_LOGRADOURO,'sk_local'))as sk_local   
            ,count(Cast(NUM_BO as Int)) as QT_BO         
        FROM crimes
        group by 1, 2
    '''
)

dim_local.coalesce(1).write.format("csv").mode('overwrite').save('dim_local.csv',header=True)
dim_delegacia.coalesce(1).write.format("csv").mode('overwrite').save('dim_delegacia.csv',header=True)
ft_crimes.coalesce(1).write.format("csv").mode('overwrite').save('ft_crimes.csv',header=True)
