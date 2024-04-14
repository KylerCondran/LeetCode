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