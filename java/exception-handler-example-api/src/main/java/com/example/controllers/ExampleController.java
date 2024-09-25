package com.example.controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.CrossOrigin;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.example.controllers.Base.BaseController;
import com.example.models.Teste;
import com.example.models.response.ApiReturn;
import com.example.models.response.ApiReturnBuilder;
import com.example.services.interfaces.ExampleService;

import io.swagger.v3.oas.annotations.tags.Tag;

@Tag(name = "Tutorial", description = "Tutorial management APIs")
@CrossOrigin(origins = "http://localhost:8081")
@RestController
@RequestMapping("/examples")
public class ExampleController extends BaseController {
    private final ExampleService exampleService;

    public ExampleController(ExampleService exampleService)
    {
        this.exampleService = exampleService;
    }

    @GetMapping("/timeout")
    public ResponseEntity<ApiReturn> SimulateTimeoutExeption()
    {
        var response = exampleService.simulateTimeoutException();
        return ok(ApiReturnBuilder.buildSuccessResponse(response));
    }

    @GetMapping("/badgateway")
    public ResponseEntity<ApiReturn> SimulateBadGatewayExeption()
    {
        var response = exampleService.simulateBadGatewayException();
        return ok(ApiReturnBuilder.buildSuccessResponse(response));
    }

    @GetMapping("/success")
    public ResponseEntity<ApiReturn> SimulateSuccessResponse()
    {
        return ok(ApiReturnBuilder.buildSuccessResponse(new Teste()));
    }
}