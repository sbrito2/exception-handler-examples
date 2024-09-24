package com.example.infrastructure.Exceptions.logger;

import java.io.PrintWriter;
import java.io.StringWriter;
import java.time.LocalDateTime;
import java.time.ZoneOffset;
import java.time.format.DateTimeFormatter;
import java.util.LinkedHashMap;
import java.util.Map;

import org.slf4j.Logger;
import org.slf4j.LoggerFactory;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.core.env.Environment;
import org.springframework.scheduling.annotation.Async;
import org.springframework.stereotype.Component;

import com.example.infrastructure.Exceptions.base.CustomizedException;
import com.example.infrastructure.Exceptions.base.Trackable;
import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;

@Component
public class CustomizedExceptionLogger {
    private String applicationEnvironment;
    private String applicationName;
    private Logger logger;
    private ObjectMapper mapper;

    public CustomizedExceptionLogger(Environment environment, ObjectMapper mapper, @Value("${spring.application.name}") String applicationName) {
        this.applicationEnvironment = String.join(",", environment.getActiveProfiles());
        this.applicationName = applicationName;
        this.logger = LoggerFactory.getLogger(applicationName);
        this.mapper = mapper;
    }

    @Async
    public void logException(CustomizedException ex) {
        logException(ex, null, null);
    }
    
    @Async
    public void logException(Throwable ex, String processName, String extraInfo) {
        serializeAndLogException(ex, processName, extraInfo, null);
    }

    private void serializeAndLogException(Throwable ex, String processName, String extraInfo, Map<String, String> contextInfo) {
        ex.printStackTrace();
        try {
            logger.error(mapper.writeValueAsString(createParams(processName, extraInfo, ex, contextInfo)));
        } catch (JsonProcessingException e) {
            e.printStackTrace();
        }
    }

    private Map<String, Object> createParams(String processName, String extraInfo, Throwable ex, Map<String, String> contextInfo) {
        StringWriter stringWriter = new StringWriter();

        try (PrintWriter printWriter = new PrintWriter(stringWriter)) {
            ex.printStackTrace(printWriter);

            Map<String, Object> fields = new LinkedHashMap<>(12);
            fields.put("level", "error");
            fields.put("environment", applicationEnvironment);
            fields.put("process", processName);
            fields.put("errorType", getExceptionType(ex));
            fields.put("message", ex.getMessage());
            fields.put("details", extraInfo);
            fields.put("tracking", getTrackingNumber(ex));
            fields.put("timestamp", LocalDateTime.now(ZoneOffset.UTC).format(DateTimeFormatter.ofPattern("yyyy-MM-dd'T'HH:mm:ss.SS")));
            
            return fields;
        }
    }

    private String getTrackingNumber(Throwable ex) {
        if (ex instanceof Trackable trackable)
            return trackable.getTracking();
        return java.util.UUID.randomUUID().toString();
    }

    private String getExceptionType(Throwable ex) {
        if (ex instanceof CustomizedException customizedException)
            return customizedException.getExceptionType().toString();
        return null;
    }

}
