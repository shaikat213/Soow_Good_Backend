pipeline {  
 agent any  
 environment {  
  dotnet = 'C:\\Program Files\\dotnet\\dotnet.exe'  
 }  
 stages {  
  stage('Checkout') {  
   steps {
     git branch: 'Development', credentialsId: '1913830b-9834-4d77-a0ea-350f8c8a6ca2', url: 'https://github.com/Coppanet-Org/SoowGood_New_Backend.git'
   }  
  }  
 stage('Build') {  
   steps {  
    bat 'dotnet build %WORKSPACE%\\SoowGoodWeb.sln --configuration Release'
 
   }  
  }  
  
  stage("Release"){
      steps {
      bat 'dotnet build  %WORKSPACE%\\SoowGoodWeb.sln /p:PublishProfile="%WORKSPACE%\\src\\SoowGoodWeb.HttpApi.Host\\Properties\\PublishProfiles\\FolderProfile.pubxml" /p:Platform="Any CPU" /p:DeployOnBuild=true /m'
    }
  }
 
  stage('Deploy') {
    steps {
    // Stop IIS
    bat 'net stop "w3svc"'
    bat '"C:\\Program Files (x86)\\IIS\\Microsoft Web Deploy V3\\msdeploy.exe" -verb:sync -source:package="%WORKSPACE%\\src\\SoowGoodWeb.HttpApi.Host\\bin\\Debug\\net7.0\\SoowGoodWeb.HttpApi.Host.zip" -dest:auto -setParam:"IIS Web Application Name"="soowgoodapi" -skip:objectName=filePath,absolutePath=".\\\\PackageTmp\\\\Web.config$" -enableRule:DoNotDelete -allowUntrusted=true'
    bat 'net start "w3svc"'

    }
 }

 }  
} 