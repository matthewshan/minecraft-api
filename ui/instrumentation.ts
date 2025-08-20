import { registerOTel } from '@vercel/otel'
import { OTLPTraceExporter } from '@opentelemetry/exporter-trace-otlp-http';
import { BatchSpanProcessor, SimpleSpanProcessor } from '@opentelemetry/sdk-trace-node';

export function register() {
  if (process.env.NEXT_RUNTIME === 'nodejs') {
    const spanProcessors: any[] = [new BatchSpanProcessor(new OTLPTraceExporter())];
    registerOTel({ spanProcessors: spanProcessors,})
  }
}