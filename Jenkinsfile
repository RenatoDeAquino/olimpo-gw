pipeline {
  agent { label "master" }
  stages {
    stage('Clean Workspace'){
      dotnetBuild configuration: 'Release', sdk: 'dotnet-teste', unstableIfWarnings: true
    }
  }
}
