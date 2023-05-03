import type Province from "./province";

export const convertToProvince = (
  { provinceCode, provinceName }: { provinceCode: number, provinceName: string }
): Province => {
  return {
    id: provinceCode,
    name: provinceName
  } as Province
}