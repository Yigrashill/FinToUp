import React, { useState } from 'react'
import { FinanceProps } from '../../Types/Interfaces/Finance/FinanceProps';
import { formatDate, getFinanceTypeName } from '../../Services/UtilityService';
import FinanceTypeComp from './FinanceTypeComp';

const FinanceItem: React.FC<FinanceProps> = ({ finance }) => {
  
  return (
      <tr>
            
        <td className="px-6 py-4 whitespace-nowrap">
            <div className="flex items-center">
              <div className="text-sm font-medium text-gray-900">
                { finance.title }
              </div>
            </div>
        </td>

        <td className="p-4 border-b border-blue-gray-50">
            <p className="block antialiased font-sans text-sm leading-normal text-blue-gray-900 font-normal">
                { finance.amount } zł
            </p>
        </td>

        <td className="p-4 border-b border-blue-50">
          <FinanceTypeComp financeType={finance.financeType} />
        </td>

        <td className="p-4 border-b border-blue-gray-50">
            <p className="block antialiased font-sans text-sm leading-normal text-blue-gray-900 font-normal">
               { formatDate(finance.createrd) }
            </p>
        </td>

      </tr>
  )
}

export default FinanceItem