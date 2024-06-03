// test-center.model.ts
export interface TestCenter {
  id: number;
  processes: BaseProcess[];
}

// base-process.model.ts
export interface BaseProcess {
  id: number;
  devices: BaseDevice[];
}

// base-device.model.ts
export interface BaseDevice {
  id: number;
  ipAddress: string;
  registers: Register[];
}

// register.model.ts
export interface Register {
  id: number;
  tagName: string;
  address: string;
  value: string;
  isWritable: boolean;
  isReadable: boolean;
}
