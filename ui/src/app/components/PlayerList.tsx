import { PlayerListResponse } from '../models/player';
// import Image from 'next/image'

export interface PlayerListProps {
  data: PlayerListResponse;
}

export function PlayerList({data}: PlayerListProps) {
  return (
    <div className="space-y-4">
      {data.players.map((player) => (
        <div key={player.uuid} className="flex items-center gap-2">
          <img src={`https://mc-heads.net/avatar/${player.uuid}`} className="w-8 h-8" alt={player.username} />
          <span>{player.username}</span>
        </div>
      ))}
    </div>
  );
}