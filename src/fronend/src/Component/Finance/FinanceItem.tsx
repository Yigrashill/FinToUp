import React, { useState } from 'react'
import { FinanceProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { formatDate, getFinanceTypeName } from '../../Services/UtilityService';
import { FinanceType } from '../../Types/Enum/FinanceType';

const FinanceItem: React.FC<FinanceProps> = ({ finance }) => {
  
  return (
      <tr>
        <td className="p-4 border-b border-blue-gray-50">
            <div className="flex items-center gap-3">
                <p className="block antialiased font-sans text-sm leading-normal text-blue-900 font-bold">
                { finance.title }
                </p>
            </div>
        </td>
        <td className="p-4 border-b border-blue-gray-50">
            <p className="block antialiased font-sans text-sm leading-normal text-blue-gray-900 font-normal">
                { finance.amount } zł
            </p>
        </td>

        {
           finance.financeType === FinanceType.Assets ?  (
            <td className="p-4 border-b border-blue-50">
            <div className="w-max">
              <div className="relative grid items-center font-sans font-bold uppercase whitespace-nowrap select-none bg-green-500/20 text-green-900 py-1 px-2 text-xs rounded-md">
                <span className="">
                  { getFinanceTypeName(finance.financeType) }
                </span>
              </div>
            </div>
          </td>
           ):(
            <td className="p-4 border-b border-blue-50">
            <div className="w-max">
              <div className="relative grid items-center font-sans font-bold uppercase whitespace-nowrap select-none bg-red-500/20 text-red-900 py-1 px-2 text-xs rounded-md">
                <span className="">
                  { getFinanceTypeName(finance.financeType) }
                </span>
              </div>
            </div>
          </td>
           )
        }

        <td className="p-4 border-b border-blue-gray-50">
            <p className="block antialiased font-sans text-sm leading-normal text-blue-gray-900 font-normal">
               { formatDate(finance.createrd) }
            </p>
        </td>

      </tr>
  )
}

export default FinanceItem