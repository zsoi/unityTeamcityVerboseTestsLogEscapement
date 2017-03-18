# Reproduction project for malformed teamcity service messages

Reproduction project for malformed teamcity service messages produced by the unity test runner verbose log

Test Tools TeamCity Verbose Log does not escape messages

# What happened

When running tests in the TeamCity CI, TeamCity complains about malformed service messages

# How we can reproduce it using the example you attached

Run the unity editor in batch mode for this project as a TeamCity build step:

Unity.exe -batchmode -quit -logFile - -projectPath %path-to-project% -runEditorTests -editorTestsResultFile="testresults.xml" -editorTestsVerboseLog teamcity

On the other hand, it is pretty easy to see in the log file that unity won't correctly escape the messages:

##teamcity[testStarted name='NewEditorTest.EditorTest("Juppi[]")']

should be

##teamcity[testStarted name='NewEditorTest.EditorTest("Juppi|[|]")']

(see the team city documentation: https://confluence.jetbrains.com/display/TCD10/Build+Script+Interaction+with+TeamCity#BuildScriptInteractionwithTeamCity-Escapedvalues )

But it seems that Unity will try to c-escape the message values, which further breaks compatibility (it really should only be escaped with the pipe symbol!)

##teamcity[testStarted name='NewEditorTest.EditorTest("Do\nDe\nDo\rLe\rFo")']

should be

##teamcity[testStarted name='NewEditorTest.EditorTest("Do|nDe|nDo|rLe|rFo")']
