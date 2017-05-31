package me.test.first.spring.cloud.eureka.sp

import groovy.transform.CompileStatic
import org.springframework.boot.SpringApplication
import org.springframework.boot.autoconfigure.SpringBootApplication

/**
 *
 */
@SpringBootApplication
@CompileStatic
class ScEurekaSpApp {

    static void main(String[] args) throws Exception {
        SpringApplication.run(ScEurekaSpApp.class, args)
    }

}