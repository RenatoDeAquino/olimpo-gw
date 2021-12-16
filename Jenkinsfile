pipeline {
  agent { label "build && windows" }
  stages {
    stage('Clean Workspace'){
      dotnetBuild configuration: 'Release', sdk: 'dotnet-teste', unstableIfWarnings: true
    }
  }
}
