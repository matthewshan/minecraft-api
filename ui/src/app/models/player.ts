export interface Player {
    username: string;
    uuid: string;
}

export interface PlayerListResponse {
    players: Player[];
}