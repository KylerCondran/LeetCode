import pandas as pd
#Title: 2879. Display the First Three Rows
#Link: https://leetcode.com/problems/display-the-first-three-rows
#Tags: Python, Database
def selectFirstRows(employees: pd.DataFrame) -> pd.DataFrame:
    df = pd.DataFrame(employees)
    return df.head(3)