# TestCaseFilterInvalidFormatBugRepro

This repository contains a minimal NUnit test project with a single test that Visual Studio 16.2.0's Test Explorer won't be able to execute.


## When the test is run in Visual Studio 16.2.0 Test Explorer

Trying to run the test will result in the following error (visible in the *Output* window when *Show output from* is set to *Tests*):

> ```
> [26 Jul 2019 2:03:16.285 PM Informational] ---------- Discovery started ----------
> [26 Jul 2019 2:03:16.300 PM Informational] ========== Discovery skipped: All test containers are up to date ==========
> [26 Jul 2019 2:03:16.306 PM Informational] ---------- Run started ----------
> [26 Jul 2019 2:03:17.418 PM Informational] NUnit Adapter 3.13.0.0: Test execution started
> [26 Jul 2019 2:03:17.427 PM Error] An exception occurred while invoking executor 'executor://nunit3testexecutor/': Incorrect format for TestCaseFilter Error: Invalid Condition 'FullyQualifiedName=Tests.Test => True'. Specify the correct format and try again. Note that the incorrect format can lead to no test getting executed.
> [26 Jul 2019 2:03:17.498 PM Informational] ========== Run finished: 0 tests run (0:00:01,1892526) ==========
> ```


## When run on the console using `vstest.console`

Works fine:

> ```
> vstest.console .\TestCaseFilterInvalidFormatBugRepro.dll
> ```
>
> ```
> Microsoft (R) Test Execution Command Line Tool Version 16.2.0
> Copyright (c) Microsoft Corporation.  All rights reserved.
> 
> Starting test execution, please wait...
> NUnit Adapter 3.13.0.0: Test execution started
> Running all tests in ...\TestCaseFilterInvalidFormatBugRepro\bin\Debug\netcoreapp2.2\.\TestCaseFilterInvalidFormatBugRepro.dll
>    NUnit3TestExecutor converted 1 of 1 NUnit test cases
> NUnit Adapter 3.13.0.0: Test execution complete
>   √ Test(() => True) [6ms]

> Test Run Successful.
> Total tests: 1
>      Passed: 1
>  Total time: 1,0082 Seconds
> ```
