package com.example.controllers.Base;

import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import com.example.models.response.ApiReturn;

public class BaseController {
    protected ResponseEntity<ApiReturn> ok(ApiReturn apiReturn) {
        if (apiReturn.isHasNotifications())
            return new ResponseEntity<>(apiReturn, HttpStatus.BAD_REQUEST);

        var httpCode = this.getHttpStatusCode(apiReturn);
        return new ResponseEntity<>(apiReturn, httpCode);
    }

    private  HttpStatus getHttpStatusCode(ApiReturn apiReturn) {
        if (apiReturn == null) {
            return HttpStatus.UNPROCESSABLE_ENTITY;
        }
        if (apiReturn.isErrorOccurred()) {
            return HttpStatus.BAD_REQUEST;
        }
        return HttpStatus.OK;
    }
}


