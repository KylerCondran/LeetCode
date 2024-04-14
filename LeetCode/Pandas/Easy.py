import pandas as pd
#Title: 2879. Display the First Three Rows
#Link: https://leetcode.com/problems/display-the-first-three-rows
#Tags: Database
def selectFirstRows(employees: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(employees)
    return df.head(3)
#Title: 2881. Create a New Column
#Link: https://leetcode.com/problems/create-a-new-column
#Tags: Database
def createBonusColumn(employees: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(employees)
    df['bonus'] = df.apply(lambda column: column.salary * 2, axis=1)
    return df
#Title: 2884. Modify Columns
#Link: https://leetcode.com/problems/modify-columns
#Tags: Database
def modifySalaryColumn(employees: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(employees)
    df.salary *= 2
    return df
#Title: 2880. Select Data
#Link: https://leetcode.com/problems/select-data
#Tags: Database
def selectData(students: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(students)
    nameage = df[["name", "age"]]
    nameage = nameage.loc[df['student_id'] == 101]
    return nameage
#Title: 2877. Create a DataFrame from List
#Link: https://leetcode.com/problems/create-a-dataframe-from-list
#Tags: Database
def createDataframe(student_data: List[List[int]]) -> pd.DataFrame:
    lst = student_data
    df = pd.DataFrame(lst, columns =['student_id', 'age']) 
    return df
#Title: 2878. Get the Size of a DataFrame
#Link: https://leetcode.com/problems/get-the-size-of-a-dataframe
#Tags: Database
def getDataframeSize(players: pd.DataFrame) -> List[int]:
    df = pd.DataFrame(players)
    vals = [len(df.index), len(df.columns)]
    return vals
#Title: 2885. Rename Columns
#Link: https://leetcode.com/problems/rename-columns
#Tags: Database
def renameColumns(students: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(students)
    df = df.rename(columns={'id': 'student_id', 'first': 'first_name', 'last': 'last_name', 'age': 'age_in_years'})
    return df
#Title: 2886. Change Data Type
#Link: https://leetcode.com/problems/change-data-type
#Tags: Database
def changeDatatype(students: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(students)
    df[["grade"]] = df[["grade"]].astype('int')
    return df
#Title: 2883. Drop Missing Data
#Link: https://leetcode.com/problems/drop-missing-data
#Tags: Database
def dropMissingData(students: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(students)
    df = df[~df['name'].isnull()]
    return df
#Title: 2882. Drop Duplicate Rows
#Link: https://leetcode.com/problems/drop-duplicate-rows
#Tags: Database
def dropDuplicateEmails(customers: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(customers)
    df = df.drop_duplicates(subset='email', keep="first")      
    return df
#Title: 2887. Fill Missing Data
#Link: https://leetcode.com/problems/fill-missing-data
#Tags: Database
def fillMissingValues(products: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(products)
    df["quantity"].fillna(0, inplace = True)    
    return df
#Title: 2888. Reshape Data: Concatenate
#Link: https://leetcode.com/problems/reshape-data-concatenate
#Tags: Database
def concatenateTables(df1: pd.DataFrame, df2: pd.DataFrame) -> pd.DataFrame:
    df1 = pd.DataFrame(df1)
    df2 = pd.DataFrame(df2)
    frames = [df1, df2]
    result = pd.concat(frames)
    return result
#Title: 2891. Method Chaining
#Link: https://leetcode.com/problems/method-chaining
#Tags: Database
def findHeavyAnimals(animals: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(animals)   
    df = df[df['weight'] > 100].sort_values('weight', ascending=False)  
    df = df[["name"]]
    return df
#Title: 2889. Reshape Data: Pivot
#Link: https://leetcode.com/problems/reshape-data-pivot
#Tags: Database
def pivotTable(weather: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(weather)
    df = pd.pivot_table(df, values = 'temperature', index='month', columns = 'city', aggfunc="max")
    return df
#Title: 2890. Reshape Data: Melt
#Link: https://leetcode.com/problems/reshape-data-melt
#Tags: Database
def meltTable(report: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(report)
    df = pd.melt(df, id_vars=['product'], value_vars=['quarter_1', 'quarter_2', 'quarter_3', 'quarter_4'], var_name='quarter', value_name='sales')
    return df