package com.example.controllers;

import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RestController;

import com.example.controllers.Base.BaseController;
import com.example.models.response.ApiReturn;
import com.example.models.response.ApiReturnBuilder;
import com.example.services.interfaces.ExampleService;

@RestController
// @RequestMapping("/examples")
public class ExampleController extends BaseController {
    private final ExampleService exampleService;

    public ExampleController(ExampleService exampleService)
    {
        this.exampleService = exampleService;
    }

    // @GetMapping("/timeout")
    // // @RequestMapping(value = "/timeout", method = RequestMethod.GET)
    // public ResponseEntity<ApiReturn> SimulateTimeoutExeption()
    // {
    //     var response = exampleService.simulateTimeoutException();
    //     return ok(ApiReturnBuilder.buildSuccessResponse(response));
    // }

    // @GetMapping("/badgateway")
    // public ResponseEntity<ApiReturn> SimulateBadGatewayExeption()
    // {
    //     var response = exampleService.simulateBadGatewayException();
    //     return ok(ApiReturnBuilder.buildSuccessResponse(response));
    // }

    // @GetMapping("/success")
    // public ResponseEntity<ApiReturn> SimulateSuccessResponse()
    // {
    //     return ok(ApiReturnBuilder.buildSuccessResponse());
    // }
}