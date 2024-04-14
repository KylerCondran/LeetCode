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