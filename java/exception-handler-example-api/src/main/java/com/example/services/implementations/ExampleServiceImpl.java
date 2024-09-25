package com.example.services.implementations;

import java.util.concurrent.TimeoutException;

import org.springframework.stereotype.Service;

import com.example.infrastructure.exception.base.CustomizedException;
import com.example.services.interfaces.ExampleService;

@Service
public class ExampleServiceImpl implements ExampleService {

    @Override
    public boolean simulateTimeoutException() {
        try {
            throw new TimeoutException("teste");
        } catch (TimeoutException error) {
            throw CustomizedException.ofTimeOut(error.getMessage());
        }

    }

    @Override
    public boolean simulateBadGatewayException() {
        throw CustomizedException.ofBadGateway("teste");
    }
}
