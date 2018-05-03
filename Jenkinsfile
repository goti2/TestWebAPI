pipeline {
  agent any
  stages {
    stage('SendMail') {
      steps {
        mail(subject: 'test', body: 'test', from: 'test', to: 'gotirw@gmail.com')
        build(job: 'test-job', quietPeriod: 5)
      }
    }
  }
}