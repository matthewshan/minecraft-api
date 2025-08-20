import { PlayerListResponse } from '@/app/models/player';
import axios from 'axios';
import { NextResponse } from 'next/server';
import { LoggerProvider } from '@opentelemetry/sdk-logs';

const loggerProvider = new LoggerProvider();
const logger = loggerProvider.getLogger('nextjs-logger');

const MINECRAFT_API_URL = process.env.MINECRAFT_API_URL;

export async function GET() {
    try {
        logger.emit({
            severityText: 'INFO',
            body: 'Listing players from Minecraft API. Uri: \'{ui}\'',
            attributes: {
                uri: `${MINECRAFT_API_URL}/api/players`
            }
        });
        const uri = `${MINECRAFT_API_URL}/api/players`;
        console.log(`Listing players from Minecraft API: '${uri}'`);
        const response = await axios.get(`${MINECRAFT_API_URL}/api/players`);
        return NextResponse.json<PlayerListResponse>(response.data);
    } catch (error) {
        console.error("Error listing players:", error);
        return new NextResponse("Failed to list players", { status: 500 });
    }
}