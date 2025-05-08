pipeline {
    agent any

    triggers {
        githubPush() // GitHub push tetikleyicisi
    }

    stages {
        stage('Checkout') {
            steps {
                git url: 'https://github.com/JegBaha/YazilimDeneme.git', branch: 'master', credentialsId: '7112aeee-81fa-4d0e-9542-ed1518e4be10'
            }
        }

        stage('Build') {
            steps {
                script {
                    // UTF-8 karakter kodlamasına geçiş
                    bat 'chcp 65001'

                    // Çalışma dizinini yazdırma
                    bat 'echo %cd%'

                    // Dosya yolunu kontrol etme
                    bat 'if exist "C:\\Users\\bahab\\source\\repos\\YazilimDeneme\\YazilimDeneme.sln" (echo File exists) else (echo File does not exist)'

                    def msBuildPath = '"C:\\Program Files\\Microsoft Visual Studio\\2022\\Community\\MSBuild\\Current\\Bin\\MSBuild.exe"'
                    def solutionFile = '"C:\\Users\\bahab\\source\\repos\\YazilimDeneme\\YazilimDeneme.sln"'
                    bat "${msBuildPath} ${solutionFile} /p:Configuration=Release"
                }
            }
        }

        stage('Deploy') {
            steps {
                script {
                    echo 'Deploying application...'

                    // Çalıştırılabilir dosyanın var olup olmadığını kontrol etme
                    def exeFile = 'C:\\Users\\bahab\\source\\repos\\YazilimDeneme\\YazilimDeneme\\bin\\Release\\YazilimDeneme.exe'
                    if (fileExists(exeFile)) {
                        echo "Executable exists: ${exeFile}"
                        // Uygulamayı yerel olarak çalıştırma
                        bat "start \"\" \"${exeFile}\""
                    } else {
                        echo "Executable not found: ${exeFile}"
                    }
                }
            }
        }
    }

    post {
        always {
            script {
                archiveArtifacts artifacts: '**/bin/**/*.*', allowEmptyArchive: true
            }
        }
        success {
            echo 'Build başarılı!'
        }
        unstable {
            echo 'Build tamamlandı fakat bazı sorunlar oluştu.'
        }
        failure {
            echo 'Build başarısız oldu.'
        }
    }
}