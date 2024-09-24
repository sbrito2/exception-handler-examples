package com.example.infrastructure.Exceptions.handler;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.bind.annotation.RestControllerAdvice;

import com.example.infrastructure.Exceptions.base.CustomizedException;
import com.example.infrastructure.Exceptions.enums.ExceptionType;
import com.example.infrastructure.Exceptions.logger.CustomizedExceptionLogger;
import com.example.models.response.ApiReturn;
import com.example.models.response.ApiReturnBuilder;

@RestControllerAdvice
public class CustomizedExceptionHandler {

    private final CustomizedExceptionLogger logger;

    public CustomizedExceptionHandler(CustomizedExceptionLogger logger) {
        this.logger = logger;
    }

    @ExceptionHandler(CustomizedException.class)
    protected ResponseEntity<ApiReturn> handleException(CustomizedException ex) {
        logger.logException(ex);
        return new ResponseEntity<>(ApiReturnBuilder.buildErrorResponse(ex),
                this.getHttpStatusCode(ex.getExceptionType()));
    }

    private HttpStatus getHttpStatusCode(ExceptionType type) {
        switch (type) {
            case TIMEOUT:
                return HttpStatus.REQUEST_TIMEOUT;
            case BAD_GATEWAY:
                return HttpStatus.BAD_GATEWAY;
            case SERVICE_UNAVAILABLE:
                return HttpStatus.SERVICE_UNAVAILABLE;
            default:
                return HttpStatus.INTERNAL_SERVER_ERROR;
        }
    }

}
