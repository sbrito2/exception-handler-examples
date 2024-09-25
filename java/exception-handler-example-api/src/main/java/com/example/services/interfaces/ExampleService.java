package com.example.services.interfaces;

import com.example.models.Teste;

public interface ExampleService {
    boolean simulateTimeoutException();
    boolean simulateBadGatewayException();
    Teste simulateBusinessErrorWithNotification();
}
