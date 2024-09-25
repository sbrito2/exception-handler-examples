package com.example;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
// import org.springframework.web.servlet.config.annotation.EnableWebMvc;
import org.springframework.context.annotation.ComponentScan;

import springfox.documentation.oas.annotations.EnableOpenApi;
import springfox.documentation.swagger2.annotations.EnableSwagger2;

// @EnableWebMvc
@SpringBootApplication
@EnableSwagger2
@EnableOpenApi
@ComponentScan
public class ExceptionHandlerExampleApiApplication {

	public static void main(String[] args) {
		SpringApplication.run(ExceptionHandlerExampleApiApplication.class, args);
	}

}
